using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGP
{
    public class RomanToNumber
    {
 	public int toNumber(String romanstring) 
	{
        char[] Tab = romanstring.ToCharArray();
		int Res = 0;
		int Suivant;
		
		for (int i = 0; i < Tab.Length; ++i)
		{
			if (Tab[i] == 'I') //conversion I
			{
                if (i + 1 < Tab.Length)
				{
					Suivant = toNumber (Tab[i+1]+"");
					
					if (Suivant > 1 && Suivant <= 10)
					{
						Res += Suivant - 1;
						++i;
					}
					
					else if (Suivant > 10)
						return -2000;
					else
						Res += 1;
				}
				else
					Res += 1;
			}
			
			else if (Tab[i] == 'V') //conversion V
			{
                if (i + 1 < Tab.Length)
				{
					Suivant = toNumber (Tab[i+1]+"");
					if (Suivant > 10)
					{
						return -2000;
					}
					else
						Res += 5;
				}
				else
				Res += 5;
			}
			
			else if(Tab[i] == 'X') 	//conversion X
			{
                if (i + 1 < Tab.Length)
				{
					Suivant = toNumber (Tab[i+1]+"");
					if (Suivant > 10 && Suivant <= 100)
					{
						Res += Suivant - 10;
						++i;
					}
					else
						Res += 10;
				}
				else
					Res += 10;
			}
			
			else if(Tab[i] == 'L') //conversion L
			{
                if (i + 1 < Tab.Length)
				{
					Suivant = toNumber (Tab[i+1]+"");
					if (Suivant > 100)
					{
						return -2000;
					}
					else
						Res += 50;
				}
				else
					Res += 50;
			}
			
			else if(Tab[i] == 'C') //conversion C
			{
                if (i + 1 < Tab.Length)
				{
					Suivant = toNumber (Tab[i+1]+"");
					if (Suivant > 100 && Suivant <= 1000)
					{
						Res += Suivant - 100;
						++i;
					}
					else
						Res += 100;
				}
				else
					Res += 100;
			}
			
			else if (Tab[i] == 'D') //conversion D
			{
                if (i + 1 < Tab.Length)
				{
					Suivant = toNumber (Tab[i+1]+"");
					if (Suivant > 500)
					{
						return -2000;
					}
					else
						Res += 500;
				}
				else
					Res += 500;
			}
			
			else if(Tab[i] == 'M') //conversion M
				Res += 1000;

            else if (Tab[i] == 'A') //conversion A
                Res += 5000;
            else if (Tab[i] == 'B') //conversion B
                Res += 10000;
            else if (Tab[i] == 'z') //conversion z
                Res += 50000;
			else 
				return -2000;
		}//if
		
		return Res;
	}// toNumber()
	
}// RomanToNumber 
    
}
