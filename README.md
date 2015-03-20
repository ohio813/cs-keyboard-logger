#cs-keyboard-logger

**cs-keyboard-logger** is a key logger that can records keystrokes in the
machine on which it was executed once. It does not require administrator
priviliges to be executed on a computer. Once, executed it runs in the
background, and automatically registers itself as a startup program. From
then on, it records the keystrokes in scan-code and text format.

The recorded keystokes are saved in `C:\Program_Files\cs-keyboard-logger`.
This folder will contain 3 files, namely, `head.log`, `<username>-key.log`,
and `<username>-text.log`. `head.log` contains the name of the two user files
in it. `<username>-key.log` contains the keystrokes in readable scan-code format.
`<username>-text.log` conatins the keystrokes in standard text format (along
with special keys as well).

Keystrokes are also saved onto the [cloud](http://iron.io) in a similar fashion
to that as mentioned above i case of files. However, instead of files, it is
stored in message queues, with names `head`, `<username>-key`, and `<username>-text`.
Now, that means you can monitor your target's keystrokes from anywhere. And, 
there is more. You can monitor multiple targets at the same time from your cloud
(it will be stored separately for each user in seperate queues). The `head` queue
can be used to keep track of the order in which you gained your targets and times
when they restarted their computers.
