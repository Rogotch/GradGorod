using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Интерфейс, определяющий, как, какой и на каких условиях в ScrollView будут добавляться новые объекты
    /// </summary>
    public interface ISVItem
    {
        /// <summary>
        /// Определение конкретного объекта, который будет уникальным с уникальными свойствами
        /// </summary>
        /// <param name="obj">Объект</param>
        void SetSelectedObject(GameObject obj);

        /// <summary>
        /// Обновить параметры объекта для изменения содержания
        /// </summary>
        void UpdateParameters();

        /// <summary>
        /// Проверить, подходит ли объект для добавления в список
        /// </summary>
        /// <returns></returns>
        bool CheckingTheCondition();
    }
}