using AdisyonApp.Entities;

namespace AdisyonApp.Business.Abstract
{
    public interface IMenuService
    {
        void CreateMenu(Menu menu);
        void UpdateMenu(Menu menu);
        void DeleteMenu(int menuId);
        Menu GetMenuById(int menuId);
    }

    
}