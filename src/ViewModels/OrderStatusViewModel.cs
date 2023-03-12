using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Создан")]
        Create,
        [Display(Name = "В работе")]
        InWork,
        [Display(Name = "Необходимо связаться")]
        NeedToContact,
        [Display(Name = "Отменен")]
        Сanceled,
        [Display(Name = "Выполнен")]
        Сompleted
    }  
}
