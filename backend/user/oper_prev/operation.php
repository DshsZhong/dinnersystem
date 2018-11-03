<?php
namespace user;

class operation
{
    public static $oper = [
        'guest' => [
            'login' => 'login',
            'logout' => 'logout'
            # This function has been disabled #
            /*'register' => 'register'*/
        ],
        'normal' => [
            'change_password' => 'change_password',
            'show_dish' => 'show_dish',
            'select_self' => 'show_order',
            'make_self_order' => 'make_order',
            'delete_self' => 'delete_order'
        ],
        'dinnerman' => [
            'change_password' => 'change_password',
            'show_dish' => 'show_dish',
            'select_class' => 'show_order',
            'make_class_order' => 'make_order',
            'delete_dm' => 'delete_order',
            'payment_usr' => 'set_payment',
            'payment_dm' => 'set_payment'
        ],
        'cafeteria' => [
            'change_password' => 'change_password',
            'show_dish' => 'show_dish',
            'update_dish' => 'update_dish',
            'select_other' => 'show_order',
            'make_everyone_order' => 'make_order',
            'delete_everyone' => 'delete_order',
            'payment_cafet' => 'set_payment'
        ],
        'factory' => [
            'change_password' => 'change_password',
            'show_dish' => 'show_dish',
            'update_dish' => 'update_dish',
            'select_facto' => 'show_order',
            'payment_facto' => 'set_payment'
        ],
        'admin' => [
            'change_password' => 'change_password',
            'update_dish' => 'update_dish',
            'select_other' => 'show_order' ,
            'make_everyone_order' => 'make_order',
            'delete_everyone' => 'delete_order',
            'get_announce' => 'announce_handle',
            'done_announce' => 'announce_handle',
            'payment_usr' => 'set_payment',
            'payment_dm' => 'set_payment',
            'payment_cafet' => 'set_payment',
            'payment_facto' => 'set_payment'
        ]
    ];

    public static function get_oper($prev)
    {
        return self::$oper[$prev];
    }
}



?>