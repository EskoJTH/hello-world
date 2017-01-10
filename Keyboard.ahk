#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.


+<!a::
   Send {Shift down}{Left}
Return

+<!d::
   Send {Shift down}{Right}
Return

+<!s::
   Send {Shift down}{Down}
Return

+<!w::
   Send {Shift down}{Up}
Return

+<!q::
   Send {Shift down}{Home}
Return

+<!e::
   Send {Shift down}{End}
Return

+<!f::
   Send {Shift down}{Enter}
Return

+<!c::
   Send {Shift down}{BS}
Return

+<!v::
   Send {Shift down}{Delete}
Return

+<!z::
   Send {Shift down}{<!}
Return

+<!,::
   Send {Shift down}{{}
Return

+<!.::
   Send {Shift down}/
Return

+<!-::
   Send {Shift down}{}}
Return








^+<!a::
   Send {Control down}{Shift down}{Left}
Return

^+<!d::
   Send {Control down}{Shift down}{Right}
Return

^+<!s::
   Send {Control down}{Shift down}{Down}
Return

^+<!w::
   Send {Control down}{Shift down}{Up}
Return

^+<!q::
   Send {Control down}{Shift down}{Home}
Return

^+<!e::
   Send {Control down}{Shift down}{End}
Return

^+<!f::
   Send {Control down}{Shift down}{Enter}
Return

^+<!c::
   Send {Control down}{Shift down}{BS}
Return

^+<!v::
   Send {Control down}{Shift down}{Delete}
Return

^+<!z::
   Send {Control down}{Shift down}{<!}
Return

^+<!,::
   Send {Control down}{Shift down}{{}
Return

^+<!.::
   Send {Control down}{Shift down}/
Return

^+<!-::
   Send {ontrol down} {Shift down}{}}
Return





^<!a::
   Send {Control down}{Left} 
Return

^<!d::
   Send {Control down}{Right}
Return

^<!s::
   Send {Control down}{Down}
Return

^<!w::
   Send {Control down}{Up}
Return

^<!q::
   Send {Control down}{Home}
Return

^<!e::
   Send {Control down}{End}
Return

^<!f::
   Send {Control down}{Enter}
Return

^<!c::
   Send {Control down}{BS}
Return

^<!v::
   Send {Control down}{Delete}
Return

^<!z::
   Send {Control down}{<!}
Return

^<!,::
   Send {Control down}{{}
Return

^<!.::
   Send {Control down}/
Return

^<!-::
   Send {Control down}{}}
Return





<!a::
   Send {Left}
Return

<!d::
   Send {Right}
Return

<!s::
   Send {Down}
Return

<!w::
   Send {Up}
Return

<!q::
   Send {Home}
Return

<!e::
   Send {End}
Return

<!f::
   Send {Enter}
Return

<!c::
   Send {BS}
Return

<!v::
   Send {Delete}
Return

<!z::
   Send {<!}
Return

<!,::
   Send {{}
Return

<!.::
   Send /
Return

<!-::
   Send {}}
Return

CapsLock::Suspend






