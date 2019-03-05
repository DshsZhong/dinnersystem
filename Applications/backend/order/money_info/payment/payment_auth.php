<?php
namespace order\money_info;

function payment_auth($row ,$uid ,$permission ,$target ,$hash ,$req_id)
{
	# password control
	if(!password_auth($row ,$hash ,$req_id))
		throw new \Exception("Wrong password");
	
	# already done control.
	if($row->money->payment["payment"]->paid == $target)
		throw new \Exception("Already done");
	
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