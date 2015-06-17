

namespace ShipDamageNew
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ShipDamage
    {
        static void Main(string[] args)
        {
            int s1x = int.Parse(Console.ReadLine());
            int s1y = int.Parse(Console.ReadLine());
            int s2x = int.Parse(Console.ReadLine());
            int s2y = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int c1x = int.Parse(Console.ReadLine());
            int c1y = int.Parse(Console.ReadLine());
            int c2x = int.Parse(Console.ReadLine());
            int c2y = int.Parse(Console.ReadLine());
            int c3x = int.Parse(Console.ReadLine());
            int c3y = int.Parse(Console.ReadLine());
            int damage = 0;
            int totalDamage = 0;

            // c checking
            if ((c1y*(-1)) == s1y)
            {
                if (((c1x-h)*(-1)) < (s1x-h))
                {
                    if ((((c1x-h)*(-1)) > (s2x-h)))
                    {
                        damage = 50;
                        totalDamage += damage;
                    }
                    else
                    {
                        if ((((c1x-h)*(-1)) == (s2x-h)))
                        {
                            damage = 25;
                            totalDamage += damage;
                        }
                    }
                   
                }
                else
                {
                    if ((((c1x-h)*(-1)) == (s1x-h)))
                    {
                        damage = 25;
                        totalDamage += damage;
                    }
                }
                
            }
            else
            {
                if ((c1y * (-1)) == s2y)
                {
                    if (((c1x - h) * (-1)) < (s1x - h))
                    {
                        if ((((c1x - h) * (-1)) > (s2x - h)))
                        {
                            damage = 50;
                            totalDamage += damage;
                        }
                        else
                        {
                            if ((((c1x - h) * (-1)) == (s2x - h)))
                            {
                                damage = 25;
                                totalDamage += damage;
                            }
                        }

                    }
                    else
                    {
                        if ((((c1x - h) * (-1)) == (s1x - h)))
                        {
                            damage = 25;
                            totalDamage += damage;
                        }
                    }

                }

            }
            if ((c1x+h == s1x-h) | (c1x+h == s2x-h))
            {
                if (c1y < s1y)
                {
                    if (c1y > s2y)
                    {
                        damage = 50;
                        totalDamage += damage;
                    }
                }
            }
            if ((c1x+h < s1x-h) && (c1x+h >s2x-h))
            {
                if ((c1y < s1y) && (c1y > s2y))
                {
                    damage = 100;
                    totalDamage += damage;
                }
            }
            // c2 checking
             if (c2y == s1y)
            {
                if (((c1x-h)*(-1)) < (s1x-h))
                {
                    if ((((c1x-h)*(-1)) > (s2x-h)))
                    {
                        damage = 50;
                        totalDamage += damage;
                    }
                    else
                    {
                        if ((((c1x-h)*(-1)) == (s2x-h)))
                        {
                            damage = 25;
                            totalDamage += damage;
                        }
                    }
                   
                }
                else
                {
                    if ((((c1x-h)*(-1)) == (s1x-h)))
                    {
                        damage = 25;
                        totalDamage += damage;
                    }
                }
                
            }
            else
            {
                if (c2y == s2y)
                {
                    if (((c1x - h) * (-1)) < (s1x - h))
                    {
                        if ((((c1x - h) * (-1)) > (s2x - h)))
                        {
                            damage = 50;
                            totalDamage += damage;
                        }
                        else
                        {
                            if ((((c1x - h) * (-1)) == (s2x - h)))
                            {
                                damage = 25;
                                totalDamage += damage;
                            }
                        }

                    }
                    else
                    {
                        if ((((c1x - h) * (-1)) == (s1x - h)))
                        {
                            damage = 25;
                            totalDamage += damage;
                        }
                    }

                }

            }
            if ((c1x+h == s1x-h) | (c1x+h == s2x-h))
            {
                if (c2y < s1y)
                {
                    if (c2y > s2y)
                    {
                        damage = 50;
                        totalDamage += damage;
                    }
                }
            }
            if ((c1x+h < s1x-h) && (c1x+h >s2x-h))
            {
                if ((c2y < s1y) && (c2y > s2y))
                {
                    damage = 100;
                    totalDamage += damage;
                }
            }
            // c3 checking
            if (c3y == s1y)
            {
                if (((c1x - h) * (-1)) < (s1x - h))
                {
                    if ((((c1x - h) * (-1)) > (s2x - h)))
                    {
                        damage = 50;
                        totalDamage += damage;
                    }
                    else
                    {
                        if ((((c1x - h) * (-1)) == (s2x - h)))
                        {
                            damage = 25;
                            totalDamage += damage;
                        }
                    }

                }
                else
                {
                    if ((((c1x - h) * (-1)) == (s1x - h)))
                    {
                        damage = 25;
                        totalDamage += damage;
                    }
                }

            }
            else
            {
                if (c3y == s2y)
                {
                    if (((c1x - h) * (-1)) < (s1x - h))
                    {
                        if ((((c1x - h) * (-1)) > (s2x - h)))
                        {
                            damage = 50;
                            totalDamage += damage;
                        }
                        else
                        {
                            if ((((c1x - h) * (-1)) == (s2x - h)))
                            {
                                damage = 25;
                                totalDamage += damage;
                            }
                        }

                    }
                    else
                    {
                        if ((((c1x - h) * (-1)) == (s1x - h)))
                        {
                            damage = 25;
                            totalDamage += damage;
                        }
                    }

                }

            }
            if ((c1x + h == s1x - h) | (c1x + h == s2x - h))
            {
                if (c3y < s1y)
                {
                    if (c3y > s2y)
                    {
                        damage = 50;
                        totalDamage += damage;
                    }
                }
            }
            if ((c1x + h < s1x - h) && (c1x + h > s2x - h))
            {
                if ((c3y < s1y) && (c3y > s2y))
                {
                    damage = 100;
                    totalDamage += damage;
                }
            }
            Console.WriteLine("{0}%", totalDamage);
     
        }
    }
}
