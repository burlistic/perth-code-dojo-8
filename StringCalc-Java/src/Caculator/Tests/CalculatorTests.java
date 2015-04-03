package Caculator.Tests;

import static org.junit.Assert.*;

import org.junit.Test;

import Caculator.Calculator;

public class CalculatorTests {
	
	@Test
	public void add_returns_zero_for_emtpy_string() {
		
		Calculator calc = new Calculator();
		int result = calc.Add("");
		
		assertEquals(0, result);  
	}

	
	@Test
	public void add_returns_int_for_valid_numbers() {
		
		Calculator calc = new Calculator();
		int result = calc.Add("1");
		
		assertEquals(1, result);  		
	}
	
	@Test
	public void add_handles_simple_addition() {
		
		Calculator calc = new Calculator();
		int result = calc.Add("1,2");
		
		assertEquals(3, result);  		
	}

}




