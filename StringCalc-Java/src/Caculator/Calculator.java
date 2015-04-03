package Caculator;

public class Calculator {

	public int Add(String input) {
		
		if(input == "")
		{
			return 0;
		}
		
		String[] splitNumbers = input.split(",");
		
		int total = 0;
				
		for(String stringNumber : splitNumbers)
		{
			total += Integer.parseInt(stringNumber);
			
		}
		
		return total;
		
	}

}
