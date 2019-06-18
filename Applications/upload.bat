rmdir /s /q C:\wamp64\www\dinnersys_beta/backend
rmdir /s /q C:\wamp64\www\dinnersys_beta/frontend
robocopy backend C:\wamp64\www\dinnersys_beta/backend /s /e
robocopy frontend C:\wamp64\www\dinnersys_beta/frontend /s /e