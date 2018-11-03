from dinnersys import dinnersys
from push_announce import exec_announce
import datetime
import threading

account = input("Please input admin account :")
password = input("Please input admin password :")
interval = int(input("Please input refresh interval(in seconds) :"))      # 300 seconds
reserved_time = int(input("Please input reserved time(in seconds) :"))    # 600 seconds

ds = dinnersys(account, password)


def push_announce(*args):
    done = False
    while not done:
        try:
            item = args[0]
            exec_announce(item)
            ds.done_announce(item["id"])
            done = True
        except:
            done = False
    print("Pushed " + item["id"])

def loop():
    result = get_time()
    data = ds.get_announce(result["start"], result["end"])

    count = 0
    for item in data:
        t = threading.Thread(target=push_announce, args=(item,))
        t.start()
        count += 1
        if count >= 10:
            break

    global timer
    timer = threading.Timer(interval, loop)
    timer.start()


def get_time():
    current = datetime.datetime.now()
    current = current + datetime.timedelta(seconds=reserved_time)
    end = current.strftime('%Y/%m/%d-%H:%M:%S')
    start = "2000/01/09-00:00:00"
    return {"start": start, "end": end}


timer = threading.Timer(interval, loop)
timer.start()
