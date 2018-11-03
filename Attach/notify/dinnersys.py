import requests
import json
from encoding import remove_bom


class dinnersys:
    server_dns = "http://localhost/"
    # server_dns = "http://localhost/"
    def __init__(self, account, pswd):
        self.cookie = self.login(account, pswd)

    def login(self ,account, pswd):
        link = self.server_dns + "dinnersys_beta/backend/backend.php?cmd=login&id=" + \
            account + "&password=" + pswd
        session = requests.Session()
        resp = session.get(link)
        resp_text = remove_bom(resp.text)
        try:
            js = json.loads(resp_text)
            valid_oper = dict()
            for item in js["valid_oper"]:
                valid_oper[list(item.keys())[0]] = True
            if(not valid_oper["get_announce"]):
                raise Exception("Not enough prev")
        except TypeError:
            raise Exception("Not enough prev")
        except Exception:
            raise Exception("Invalid id/pswd")
        return session.cookies.get_dict()

    def get_announce(self ,start, end):
        link = self.server_dns + "dinnersys_beta/backend/backend.php?cmd=get_announce&start=" + \
            start + "&end=" + end
        f = requests.get(link, cookies=self.cookie)
        resp = remove_bom(f.text)
        ret = json.loads(resp)
        return ret

    def done_announce(self ,id):
        link = self.server_dns + "dinnersys_beta/backend/backend.php?cmd=done_announce&id=" + id
        f = requests.get(link, cookies=self.cookie)
        return f.text
