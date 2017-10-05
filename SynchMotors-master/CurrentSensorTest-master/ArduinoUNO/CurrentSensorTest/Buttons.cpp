#include "Buttons.h"
#include <avr/io.h>

uint8_t Buttons::timerOne = 0;
uint8_t Buttons::timerTwo = 0;
bool Buttons::buttonState[2] = {false, false};
bool Buttons::was = false;

void Buttons::initButtons(void)
{
	BUTTONS_PORT |= (1 << BUTTON_ONE)|(1 << BUTTON_TWO);
	BUTTONS_DDR &= ~((1 << BUTTON_ONE)|(1 << BUTTON_TWO));
}

void Buttons::initMotor(void)
{
	MOTOR_DDR |= (1 << LEFT_OUT_1_2)|(1 << LEFT_OUT_2_2)|(1 << RIGHT_OUT_1_1)|(1 << RIGHT_OUT_2_1)|(1 << EN_OUT_1)|(1 << EN_OUT_2);
	MOTOR_PORT &= ~((1 << LEFT_OUT_1_2)|(1 << LEFT_OUT_2_2)|(1 << RIGHT_OUT_1_1)|(1 << RIGHT_OUT_2_1)|(1 << EN_OUT_1)|(1 << EN_OUT_2));
}

void Buttons::initTimer0(void)
{
	TCCR0B |= (1 << CS02)|(0 << CS01)|(1 << CS00);
	TIMSK0 |= (1 << TOIE0);
}

void Buttons::checkButtonsState(void)
{
	if(((BUTTONS_PIN & (1 << BUTTON_ONE)) == (0 << BUTTON_ONE)) && ((BUTTONS_PIN & (1 << BUTTON_TWO)) == (1 << BUTTON_TWO)))
	{
		timerTwo = 0;
		timerOne++;
		if((timerOne > 8) && (was == false) && (buttonState[1] == false))
		{
			buttonState[0] = !buttonState[0]; 
			timerOne = 0;
			was = true;
		}
	}
	
	else if(((BUTTONS_PIN & (1 << BUTTON_ONE)) == (1 << BUTTON_ONE)) && ((BUTTONS_PIN & (1 << BUTTON_TWO)) == (0 << BUTTON_TWO)))
	{
		timerOne = 0;
		timerTwo++;
		if((timerTwo > 8) && (was == false) && (buttonState[0] == false))
		{
			buttonState[1] = !buttonState[1];
			timerTwo = 0;
			was = true;
		}
	}
	
	else
	{
		was = false;
		timerOne = 0;
		timerTwo = 0;
	}
}

bool Buttons::getButtonState(uint8_t number)
{
	return buttonState[number];
}

void Buttons::motorRotate(uint8_t direction)
{
	switch(direction)
	{
		case 0:
			MOTOR_PORT &= ~((1 << LEFT_OUT_1_2)|(1 << LEFT_OUT_2_2));
			MOTOR_PORT |= (1 << RIGHT_OUT_1_1)|(1 << RIGHT_OUT_2_1);
			break;
			
		case 1:
			MOTOR_PORT &= ~((1 << RIGHT_OUT_1_1)|(1 << RIGHT_OUT_2_1));
			MOTOR_PORT |= (1 << LEFT_OUT_1_2)|(1 << LEFT_OUT_2_2);
			break;	
	}
	
}

void Buttons::motorStop(void)
{
	MOTOR_PORT &= ~((1 << LEFT_OUT_1_2)|(1 << LEFT_OUT_2_2));
	MOTOR_PORT &= ~((1 << RIGHT_OUT_1_1)|(1 << RIGHT_OUT_2_1));
}

void Buttons::enableMotor(void)
{
	MOTOR_PORT |= (1 << EN_OUT_1)|(1 << EN_OUT_2);
}

void Buttons::disableMotor(void)
{
	MOTOR_PORT &= ~((1 << EN_OUT_1)|(1 << EN_OUT_2));
}
