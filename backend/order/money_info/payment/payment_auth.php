<?php
namespace order\money_info;

function payment_auth($row ,$uid ,$money_to ,$target)
{
	# already done control.
	if($row->money->payment[$money_to]->paid == $target)
		throw new \Exception("Already done");
	
	# date time control
	if(!\other\date_api::is_between(
		$row->money->payment[$money_to]->able_dt,
		date('Y-m-d H:i:s'),
		$row->money->payment[$money_to]->freeze_dt
	)) throw new \Exception("The payment has expired or it's not yet to pay.");
	
	# payment flow control
	switch($money_to) {
		case "user":
			if($target == false)
				if($row->money->payment['dinnerman']->paid || $row->money->payment['cafeteria']->paid)
					throw new \Exception("Require reverse 'cafet' payment and 'dm' payment");
			break;
		case "dinnerman":
			if($target)
			{
				if($row->money->payment['user']->paid == false) 
					throw new \Exception("Require finish 'usr' payment");
			}
			else
			{
				if($row->money->payment['cafeteria']->paid) 
					throw new \Exception("Require reverse 'cafet' payment");
			}
			break;
		case "cafeteria":
			if($target)
			{
				if(!$row->money->payment['dinnerman']->paid || !$row->money->payment['user']->paid)
					throw new \Exception("Require finish 'dm' payment and 'usr' payment");
			}
			break;
	}

	# reversable control
	if(!$target && !$row->money->payment[$money_to]->reversable)
		throw new \Exception("Payment is unreversable.");

	# permission control
	$me = unserialize($_SESSION['me']);
    if($money_to == 'factory')
    {
		$is_admin = false;
		foreach($me->prev as $prev) 
			$is_admin |= ($prev == "admin");
		$is_boss = ($row->dish->department->factory->boss_id == $me->id);
		if(!($is_admin || $is_boss))
			throw new \Exception("Access denied.");
	} 
	if($money_to == "cafeteria") 
	{
		return true;
	}
	if($money_to == "dinnerman")
	{
		if($row->user->class->id != $me->class->id)
			throw new \Exception("Access denied.");
	}
	if($money_to == "user")
	{
		if($row->user->class->id != $me->class->id)
			throw new \Exception("Access denied.");
	}
	return true;
}

?>