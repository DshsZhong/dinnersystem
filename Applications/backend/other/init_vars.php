<?php
namespace other;

function init_vars()
{
    $_SESSION['factory'] = serialize(\food\get_factory());
    $_SESSION['department'] = serialize(\food\get_department());
    $_SESSION['dish'] = serialize(\food\get_dish());
    $_SESSION['class'] = serialize(\user\get_class());
    $_SESSION['user'] = serialize(\user\get_user());
}

?>