<?php
namespace order\money_info;

function payment_auth($row ,$uid ,$permission ,$target ,$hash ,$req_id)
{
	# password control
	if(!password_auth($row ,$hash ,$req_id))
		throw new \Exception("Wrong password");
	
	# today control
	if(date("Y-m-d" ,strtotime($row->esti_recv)) != date("Y-m-d"))
		throw new \Exception("Only allow to payment for today");
	
	# date time control
	if(!\other\date_api::is_between(
		$row->money->payment["payment"]->able_dt,
		date('Y-m-d H:i:s'),
		$row->money->payment["payment"]->freeze_dt
	)) throw new \Exception("The payment has expired or it's not yet to pay.");

	# reversable control
	if(!$target && !$row->money->payment["payment"]->reversable)
		throw new \Exception("Payment is unreversable.");

	# permission control
	if($row->user->id != $uid && $permission != "everyone")
		throw new \Exception("Access denied.");

	return true;
}

?>