using Ictshop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.Command
{
    public class IndexCommand:ICommand
    {
        private readonly DonhangsController _controller;

        public IndexCommand(DonhangsController controller)
        {
            _controller = controller;
        }

        public void Execute()
        {
            _controller.CheckLoggedInAndDisplayOrders();
        }
    }
}