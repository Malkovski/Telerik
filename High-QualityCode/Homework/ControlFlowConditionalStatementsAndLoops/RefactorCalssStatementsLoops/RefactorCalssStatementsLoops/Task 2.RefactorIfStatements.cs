//Potato potato;
//... 
//if (potato != null)
//   if(!potato.HasNotBeenPeeled && !potato.IsRotten)
//    Cook(potato);
//and

//if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
//{
//   VisitCell();
//}

Potato potato;

//... 

if (potato != null)
{
    if (potato.HasBeenPeeled && !potato.IsRotten)
    {

    }
    else
    {
        // ...
    }
}
else
{
    // ...
}
    
Cook(potato);

// ..............................................

bool yCoordinateInRange = MAX_Y >= y && MIN_Y <= y;
bool inRange = x >= MIN_X && (x <= MAX_X && (yCoordinateInRange && shouldVisitCell));

if (inRange)
{
   VisitCell();
}
