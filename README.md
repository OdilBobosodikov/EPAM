# Практические задания

Создать структуру "Координата", определяющую 3D координаты некоторого объекта (положительные числа). Определить интерфейс IFlyable с методами FlyTo(новая точка), GetFlyTime(новая точка). Создать классы "Птица", "Самолет", "Дрон", реализующие данный интерфейс и содержащие как миминум поле "Текущее положение".

Использовать следующие предположения: птица летит все расстояние с постоянной скоростью в диапазоне 0-20 км/ч (заданной случайно), самолет увеличивает скорость на 10 км/ч каждые 10 км полета от начальной скорости 200 км/ч., дрон зависает в воздухе каждые 10 минут полета на 1 минуту. Исходя из задачи, ввести дополнительные ограничения(например, невозможность полета дрона на дальность более чем на 1000 км). Методы и введенные ограничения описать в комментариях.
