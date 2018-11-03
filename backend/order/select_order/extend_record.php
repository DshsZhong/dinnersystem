<?php
namespace order\select_order;

function extend_payment($rows)
{
    $oids = [];
    foreach($rows as $row)
        $oids[] = intval($row->id);
    
    $data = \order\money_info\get_payments($oids);

    foreach($oids as $oid)
    {
        $rows[$oid]->money->init_payment($data[$oid]);
    }
    return $rows;
}

function extend_buffet($rows)
{

}

function extend_cargo($rows)
{

}

?>