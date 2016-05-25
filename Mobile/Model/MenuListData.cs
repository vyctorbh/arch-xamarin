using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.PageLocator;

namespace Mobile.Model
{
    public class MenuListData : List<MenuItem>
    {
        private Main _locator = new Main();

        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Title = "Conteúdo Exclusivo",
                IconSource = "news.png",
                MainType = _locator.MainPage
            });

            this.Add(new MenuItem()
            {
                Title = "Cotação Suíno",
                IconSource = "pig.png",
                MainType = _locator.AboutPage
            });

            this.Add(new MenuItem()
            {
                Title = "Informe Intercarnes",
				IconSource = "cow.png",
                MainType = _locator.IntercarnesPage
            });

            this.Add(new MenuItem()
            {
                Title = "Pos. do Mercado",
                IconSource = "posicionamento.png",
					MainType = _locator.TabelaPage
            });
        }
    }

}
