<?php
namespace order\select_order;
use other\check_valid;
use other\date_api;

function select_order($param)
{    
    $param['user_id'] = check_valid::white_list_null($param['user_id'] ,check_valid::$integers);
    $param['usr'] = check_valid::bool_null_check($param['usr']);
    $param['dm'] = check_valid::bool_null_check($param['dm']);
    $param['cafet'] = check_valid::bool_null_check($param['cafet']);
    $param['facto'] = check_valid::bool_null_check($param['facto']);
    if($param['esti_start'] != null) $param['esti_start'] = date_api::is_valid_time($param['esti_start'])->format('Y/m/d-H:i:s');
    if($param['esti_end'] != null) $param['esti_end'] = date_api::is_valid_time($param['esti_end'])->format('Y/m/d-H:i:s');
    $param['factory_id'] = check_valid::white_list_null($param['factory_id'] ,check_valid::$only_number);
    $param['person'] = check_valid::bool_null_check($param['person']);
    $param['class'] = check_valid::bool_null_check($param['class']);
    $param['oid'] = check_valid::white_list_null($param['oid'] ,check_valid::$only_number);

    $statement = create_statement($param); 
    $result = get_orders($statement ,($param["history"] == "true"));
    $result = extend_payment($result); 
    $result = select_payment($result ,$param);

    return $result;
}

?>