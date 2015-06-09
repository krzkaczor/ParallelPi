ParallelPI
----------
Calculate PI number with given precision using `Bailey–Borwein–Plouffe` formula. Calculations are parallel thanks to `PLINQ`.

Project uses [BigNumber](http://www.codeproject.com/Articles/41945/A-BigNumber-Class-Done-in-C) class by `Zimmermann Stephan`.

Running project
---------------
Make sure that your IDE downloads missing NuGet packages for you.

Performance
-----------
I worked on MBP late 2013 running Windows on VM (it had access to 4 cores of my processor).

It took around 1 minute to compute PI with 40 000 decimal places (~60% faster than doing it without parallelization).

Implementation
--------------
I used `Bailey–Borwein–Plouffe` formula to compute PI in hexadecimal system. Unfortunately converting it to decimal number is a little bit tricky because of lack advanced `BigNumber` library for .NET (even `JavaScript` has one). I needed arbitrary precision floating-point math with support for hex numbers. Finally I used `BigInteger` and `BigNumber` classes to achieve goal.