# ihudblog
Blog
Простой сайт заметок

-Пароли хранятся в базе в виде хэшей
-файлы хранятся в папке- Files внутри проекта(вместо имени - GUID, чтобы не было конфликтов имен), а в базе ссылки на файлы
-есть атрибут черновик и автор
-пользователь может видеть свои записи и чужие опубликованные
-есть сортировка
-пользователь может изменять только свои файлы
-пользователь может удалить любого другого пользователя, кроме самого себя - роли не добавлены
-аутентификация сделана на уровне форм
