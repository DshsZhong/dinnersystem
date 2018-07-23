<?php

function load_food() 
{
    $_SESSION['menu'] = serialize(get_menu(null));
    $_SESSION['dish'] = serialize(get_dish(null ,null));
}

function load_menu()
{
    $_SESSION['menu'] = serialize(get_menu(null));
} 

function load_dish()
{
    $_SESSION['dish'] = serialize(get_dish(null ,null));
} 

?>