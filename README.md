BS
==

Implementation of the BS language as created by Mark Rendle at BuildStuff.lt 2014

BS is a general purpose Gradually typed language which can and should be used for building absolutely everything absolutely all the time.

* BS Hates programmers
* Booby trapped aztec temple pit of fail
* Programs must be edited and saved using Microsoft Word (2003)
* Compiles to ECMAScript3

##Language Features

* Significant whitespace
* Significant formatting
* 17 bit integers
* Variables must be prefixed by €
* Variable hoisting from all scopes
* Exception handling - BS has only one exception - HALT_AND_CATCH_FIRE
* Raise exceptions conditionally with `(unless <condition>)`
* String processing:
  * ' ' Single quotes for ASCII strings
  * '' '' Double single quotes for ANSI strings
  * " " Double quotes
  * "" "" Double double quotes
  * «  » European quotes are used for UTF-256
  * «« »» Double european quotes used for UTF-256 with string interpolation
* Mandatory Comments - at the end of every line, demarked by 5 spaces
* Optionally end statements with ; 
* `unless` statements must be terminated with ;
* Regex Aliasing - #define
* Line numbers are mandatory, and must increment in steps of 42
