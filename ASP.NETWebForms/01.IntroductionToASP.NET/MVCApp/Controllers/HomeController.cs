using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.ViewBag.Message = @"Cupcake ipsum dolor sit amet tiramisu gummies. Marshmallow jelly-o sweet unerdwear.com jelly beans lollipop cake candy canes chocolate cake. I love applicake pastry. I love unerdwear.com I love biscuit carrot cake dessert pastry tootsie roll. I love carrot cake jelly-o halvah I love tootsie roll candy canes jelly beans unerdwear.com. I love macaroon gingerbread donut candy gummies marshmallow. Gummi bears jelly beans I love. Candy icing cheesecake fruitcake donut oat cake lollipop. Biscuit danish I love cake sugar plum halvah donut. Soufflé jelly dragée. Marshmallow sweet candy pie soufflé cheesecake I love soufflé. Carrot cake sugar plum cheesecake donut marshmallow jelly.
Tootsie roll liquorice tootsie roll powder I love jelly beans. Sesame snaps jelly brownie soufflé bear claw jujubes. Sesame snaps gingerbread cookie croissant soufflé halvah. Bear claw dragée cookie soufflé apple pie. Pastry candy gingerbread I love bonbon pastry. Cupcake pastry tart jelly-o jelly beans applicake oat cake. I love tart chocolate carrot cake apple pie donut I love I love. Cupcake brownie tiramisu I love macaroon chupa chups cotton candy unerdwear.com cheesecake. Cookie liquorice marshmallow apple pie halvah. Wafer powder chocolate cake halvah. Donut soufflé soufflé. Biscuit fruitcake sweet I love dragée chocolate cake cake candy. I love I love ice cream halvah I love marshmallow halvah carrot cake.
I love apple pie brownie soufflé. Tiramisu fruitcake muffin toffee marshmallow. Jelly candy canes tootsie roll applicake sesame snaps. Jujubes pudding I love. Apple pie croissant tiramisu bear claw. Tart toffee donut jujubes jelly. Cupcake bonbon liquorice lollipop bonbon apple pie soufflé unerdwear.com liquorice. Apple pie macaroon caramels tootsie roll bonbon dessert. Macaroon bear claw tootsie roll sweet roll cheesecake dragée I love lemon drops chocolate bar. Cake pudding cupcake cheesecake jelly macaroon. Pudding chupa chups jelly I love tart cupcake chocolate sesame snaps. Muffin gingerbread muffin topping carrot cake lemon drops ice cream I love I love. Liquorice cake chupa chups. Oat cake lollipop biscuit topping danish muffin jelly beans jujubes sugar plum.
Gummies sweet candy canes sesame snaps. Jelly beans danish halvah lollipop. Lollipop halvah fruitcake sesame snaps danish jujubes. Powder candy canes jujubes tootsie roll caramels candy canes. I love gummi bears muffin liquorice carrot cake I love jelly beans. Sesame snaps apple pie sweet I love toffee danish I love I love cookie. I love lemon drops sesame snaps marshmallow gingerbread cake. Unerdwear.com carrot cake bonbon. Sesame snaps apple pie I love cake. Gingerbread pudding apple pie candy. Chocolate biscuit soufflé gingerbread candy applicake bonbon gummies. Dragée muffin I love marzipan unerdwear.com jelly. Soufflé macaroon I love danish tart powder cupcake I love. Candy canes croissant sweet soufflé.
Tiramisu candy canes soufflé toffee powder jelly beans. Topping I love muffin I love liquorice danish. Tart lollipop marzipan caramels fruitcake chocolate sweet roll. Halvah chocolate bar bonbon. Cheesecake halvah jelly tootsie roll danish donut sweet roll. Carrot cake cake chocolate bar cheesecake unerdwear.com I love chupa chups donut. Dessert bonbon cookie I love I love topping pie donut. Ice cream cupcake dessert lollipop chocolate cake gummi bears gummi bears croissant. Chocolate bar tart tiramisu apple pie jelly-o gingerbread lollipop I love I love. Soufflé powder cake. Sesame snaps jujubes chocolate cake oat cake pudding marzipan unerdwear.com chocolate bar sugar plum. Pudding halvah danish I love macaroon halvah sweet roll powder. Macaroon candy pudding brownie. Halvah dragée caramels sweet unerdwear.com biscuit icing muffin oat cake.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}