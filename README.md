# Инструкция к программе `SimpleWord`

## Предисловие

__Данная програма может конвертировать данные из бд с вопросами в формат `txt` фалйов или же `xml`, а также `gift` для 'Moodle'__

Программа работает строго с одним видом формата текста, в файле который ей дается как исходный.

Для преобразование в вид `linivec` нужно чтобы все вопросы, ответы, описание разделялось табуляцией ака кнопка Tab на клавиатуре. Для `xml` так же работает это условие.

Для Moodle `txt` также актуально прошлое условие. Для преобразование из документа ***Word*** необходимо весь документ преобразовать в простой файл ***`txt`***!!!!!

#

## Работа с файлами

Процедура выполнения преобразования:
- Выбрать файл
- Выбрать формат преобразования
- Вписать необходимые данные в активные поля(если таковые есть)
- Сохранить файл

## Поддерживаемые режимы

- Формат Lenivec __.txt__
- Формат Lenivec __.xml__
- Формат Moodle __.txt__
- Формат Moodle __.gift__
- Формат Moodle из Wodr документа __.gift__

*В `()` указаны выходящие форматы*

#

## Уголок разработчика
Программа еще далека от финального завершения, хотя с точки end-point'ов она готова, возможны баги или иного рода приколюхи. Но основной функционал готов. Было сложно в моменте с Word'овскими документами, но я решил придти к соглашению, что пользователь будет давать мне txt формат, а не word. Графамань та еще, но это так, отдушина.

> Разработчики это те люди, что могут создать то, что уничтожит мир, в разном понимание. Однако им интереснее создавать программы 1 + 1

> Чтобы получить банан, приходиться брать обезьяну (ООП vs function)

## Стадия разработки программы
Бета тестирование.

>Разработано [S1ither](http://github/S1ither)