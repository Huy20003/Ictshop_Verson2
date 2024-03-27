using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;
using System.Data;
using System.Data.Entity;
using System.Configuration;
using Ictshop.Models.Payment;
using PayPal.Api;

namespace Ictshop.Controllers
{
    public class GioHangController : Controller
    {
       Model1 db = new Model1();
        // GET: GioHang

        //Lấy giỏ hàng 
        public GioHang LayGioHang()
        {
            GioHang cart = Session["Cart"] as GioHang;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new GioHang();
                Session["Cart"] = cart;
            }
            return cart;
        }


        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMasp, string strUrl)
        {
            var pro = db.Sanphams.SingleOrDefault(n => n.Masp == iMasp);
            if (pro != null)
            {
                LayGioHang().AddToCart(pro);
            }
            return Redirect(strUrl);

        }
        //Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            //Kiểm tra masp
            Sanpham sp = db.Sanphams.SingleOrDefault(n => n.Masp == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            GioHang cart = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]

            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (cart != null)
            {
                cart.UpdateQuantity(iMaSP, int.Parse(f["txtSoLuong"].ToString()));


            }
            return RedirectToAction("GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSP)
        {
            //Kiểm tra masp
            Sanpham sp = db.Sanphams.SingleOrDefault(n => n.Masp == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            GioHang cart = LayGioHang();

            return RedirectToAction("GioHang");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //List<GioHang> cart = Session["cart"] as List<GioHang> ;
            GioHang cart = LayGioHang();
            return View(cart);
        }
        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            GioHang cart = LayGioHang();
            if (cart != null)
            {

                var iterator = cart.CreateIterator();
                while (iterator.HasNext())
                {
                    var item = iterator.Next();
                    iTongSoLuong += item._spQuantity;
                }
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private decimal TongTien()
        {
            decimal dTongTien = 0;
            GioHang cart = LayGioHang();
            if (cart != null)
            {
                var iterator = cart.CreateIterator();
                while (iterator.HasNext())
                {
                    var item = iterator.Next(); // Lưu phần tử hiện tại vào biến tạm
                    dTongTien += (decimal)(item._spProduct.Giatien * item._spQuantity);

                }
            }
                return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            GioHang cart = LayGioHang();
            return View(cart);

        }
        public ActionResult Partial_Item_ThanhToan()
        {
            GioHang cart = LayGioHang();
            if (cart != null)
            {
                return PartialView(cart);
            }
            return PartialView();
        }

        #region // Mới hoàn thiện
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang(FormCollection donhangForm)
        {
            //Kiểm tra đăng đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["cart"] == null)
            {
                RedirectToAction("Index", "Home");
            }

            Console.WriteLine(donhangForm);
            string diachinhanhang = donhangForm["Diachinhanhang"].ToString();
            string thanhtoan = donhangForm["MaTT"].ToString();
          
            int ptthanhtoan = Int32.Parse(thanhtoan);

            //Thêm đơn hàng
            Donhang ddh = new Donhang();
            Nguoidung kh = (Nguoidung)Session["use"];
            ViewBag.UsersList = new SelectList(db.Nguoidungs, "MaNguoiDung", "Hoten", kh.MaNguoiDung);
            GioHang cart = LayGioHang();
            ddh.MaNguoidung = kh.MaNguoiDung;
            ddh.Ngaydat = DateTime.Now;
            ddh.Thanhtoan = ptthanhtoan;
            ddh.Diachinhanhang = diachinhanhang;
            ddh.Email = kh.Email;
            ddh.Tongtien = TongTien();
            db.Donhangs.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in cart.Items)
            {
                Chitietdonhang ctDH = new Chitietdonhang();
                decimal thanhtien = TongTien();
                ctDH.Madon = ddh.Madon;
                ctDH.Masp = item._spProduct.Masp;
                ctDH.Soluong = item._spQuantity;
                ctDH.Dongia = (decimal)item._spProduct.Giatien;
                ctDH.Thanhtien = thanhtien;
                ctDH.Phuongthucthanhtoan = 1;
                db.Chitietdonhangs.Add(ctDH);
            }
            db.SaveChanges();


            if (ptthanhtoan == 2)
            {
             
                // Chuyển hướng sang action PaymentWithPayPal của controller hiện tại
                return RedirectToAction("PaymentWithPaypal", "GioHang");
            }
            var strSanPham = "";
            var _thanhtien = decimal.Zero;
            var _TongTien = decimal.Zero;
            //send mail khachHang
            foreach (var sp in cart.Items)
            {
                strSanPham += "<tr>";
                strSanPham += "<td>" + sp._spProduct.Tensp + "</td>";
                strSanPham += "<td>" + sp._spQuantity + "</td>";
                strSanPham += "<td>" + sp._spProduct.Giatien* sp._spQuantity + "</td>";
                strSanPham += "</tr>";
                _thanhtien += (decimal)sp._spProduct.Giatien * sp._spQuantity;
            }

            _TongTien = _thanhtien;
            string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/send2.html"));
            contentCustomer = contentCustomer.Replace("{{MaDon}}", ddh.Madon.ToString());
            contentCustomer = contentCustomer.Replace("{{SanPham}}", strSanPham);
            contentCustomer = contentCustomer.Replace("{{NgayDat}}", DateTime.Now.ToString("dd/MM/yyyy"));
            contentCustomer = contentCustomer.Replace("{{TenKhachHang}}", ddh.Nguoidung.Hoten.ToString());

            contentCustomer = contentCustomer.Replace("{{Email}}", ddh.Email);
            contentCustomer = contentCustomer.Replace("{{DiaChiNhanHang}}", ddh.Diachinhanhang);
            contentCustomer = contentCustomer.Replace("{{ThanhTien}}", _thanhtien.ToString());
            contentCustomer = contentCustomer.Replace("{{TongTien}}", _TongTien.ToString());
            Ictshop.DesignPattern.Mail.SendMail("ShopOnline", "Đơn hàng #" + ddh.Madon.ToString(), contentCustomer.ToString(), ddh.Email);

            cart.ClearCart();

            return View("SuccessView");


            //return RedirectToAction("Index", "Donhangs");
        }
        #endregion

        public ActionResult ThanhToanDonHang()
        {

            ViewBag.MaTT = new SelectList(new[]
                {
                    new { MaTT = 1, TenPT="Thanh toán tiền mặt" },
                    new { MaTT = 2, TenPT="Thanh toán chuyển khoản" },
                }, "MaTT", "TenPT", 1);
            GioHang cart = LayGioHang();
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }

            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            //Kiểm tra giỏ hàng
            if (Session["cart"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            Nguoidung kh = (Nguoidung)Session["use"];
            ViewBag.KH = kh;
            //ViewBag.MaNguoiDung = new SelectList(db.Nguoidungs, "MaNguoiDung", "Hoten");
            ViewBag.UsersList = new SelectList(db.Nguoidungs, "MaNguoiDung", "Hoten", kh.MaNguoiDung);

            //Kiểm tra đăng đăng nhập
            //Thêm đơn hàng
            Donhang ddh = new Donhang();
         
            decimal tongtien = 0;
            //foreach (var item in cart.Items)
            //{
            //    decimal thanhtien = TongTien();
            //    tongtien += thanhtien;
            //}
            tongtien = TongTien();
            ddh.MaNguoidung = kh.MaNguoiDung;
            ddh.Ngaydat = DateTime.Now;
            Chitietdonhang ctDH = new Chitietdonhang();
            ViewBag.tongtien = tongtien;
          
            //Session["GioHang"] = null;
            return View(ddh);

        }
        public ActionResult FailureView()
        {
            return View();

        }

        public ActionResult SuccessView()
        {
            return View();

        }
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            GioHang cart = LayGioHang();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                   
                    // Thanh toán bằng PayPal
                     //this section will be executed first because PayerID doesn't exist  
                     //it is returned by the create function call of the payment class  
                     // Creating a payment  
                     // baseURL is the url on which paypal sendsback the data.  
                        string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/giohang/PaymentWithPayPal?";
                        //here we are generating guid for storing the paymentID received in session  
                        //which will be used in the payment execution  
                        var guid = Convert.ToString((new Random()).Next(100000));
                        //CreatePayment function gives us the payment approval url  
                        //on which payer is redirected for paypal account payment  
                        var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                        //get links returned from paypal in response to Create function call  
                        var links = createdPayment.links.GetEnumerator();
                        string paypalRedirectUrl = null;
                        while (links.MoveNext())
                        {
                            Links lnk = links.Current;
                            if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                            {
                                //saving the payapalredirect URL to which user will be redirected for payment  
                                paypalRedirectUrl = lnk.href;
                            }
                        }
                      
                        // saving the paymentID in the key guid  
                        if (!string.IsNullOrEmpty(paypalRedirectUrl))
                        {
                            // saving the paymentID in the key guid  
                            Session.Add(guid, createdPayment.id);
                            return Redirect(paypalRedirectUrl);
                        }
                    }
                
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }

            cart.ClearCart();
            return View("SuccessView");



            //on successful payment, show success page to user.  

        }
        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            GioHang cart = LayGioHang();
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //var total =Math.Round(lstGioHang.Sum(n => n.ThanhTien)/23500,2);
            //Adding Item Details like name, currency, price etc  
            foreach (var item in cart.Items)
            {
                itemList.items.Add(new Item()
                {
                    name = item._spProduct.Tensp.ToString(),
                    currency = "USD",
                    price = Math.Round((double)(item._spProduct.Giatien / 23500), 2).ToString(),
                    quantity = item._spQuantity.ToString(),
                    sku = item._spProduct.Masp.ToString()
                }); ; ;
            }

            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl 
            };

            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {

                tax = "0",
                shipping = "0",
                subtotal = cart.GetTotalPriceUSD().ToString()
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = cart.GetTotalPriceUSD().ToString(), // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            var OrderPaymentId = DateTime.Now.Ticks;
            transactionList.Add(new Transaction()
            {
                description = $"Invoice #{OrderPaymentId}",
                invoice_number = OrderPaymentId.ToString(), //Generate an Invoice No    
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }


    }
}