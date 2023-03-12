using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public enum OrderStatus
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
