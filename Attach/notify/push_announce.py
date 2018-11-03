import urllib
import requests
from encoding import remove_bom

server_key = "AAAAE49kmHU:APA91bE-DPWn468f8M6ow-9Een_ac-T36luetXB0lMxat3YF655nZAfDyzcre5YjN3fv6APEgs5c6498rZHexrB2Ldl045ktTTheDsWvNBe1WKycIjRQaUA8ykrYXKyoRO24i9gqovjg"


def exec_announce(item):
    if(item["device_id"] == "website"):
        return
    # item["device_id"] = "dhqad4-TKG8:APA91bH9D3X8cbUjMbZU9eZlzenXyUTrBIqKtq7D-qfQhI1yXl2r1BLIqwr0EcQMdZd9H3TPjOLxqVaoNgeP4D66G2gbiRsbLR5xZtobPg7y1Ko6yZfJBktXTTcJlq9EEYySTQ2rJFac"
    

    header = {
        "Authorization": "key=" + server_key,
        "Content-Type": "application/json"
    }
    fields = {
        'to': item["device_id"],
        'notification': {
            "body": item["msg"],
            "title": "午餐系統點餐通知",
            'icon': 1,
            'sound': 1
        }
    }

    requests.post("https://fcm.googleapis.com/fcm/send",
                  headers=header, json=fields)
