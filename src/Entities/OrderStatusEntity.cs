using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public enum OrderStatusEntity
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
