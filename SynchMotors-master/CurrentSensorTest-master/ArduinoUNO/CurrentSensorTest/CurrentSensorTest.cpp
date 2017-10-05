/*
 * CurrentSensorTest.cpp
 *
 * Created: 28.08.2017 10:15:57
 *  Author: user
 */ 

#define F_CPU 16000000UL

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include "CurrentADC.h"
#include "CurrentADC.cpp"
#include "Uart.h"
#include "Uart.cpp"
#include "Buttons.h"
#include "Buttons.cpp"
#include "Settings.h"
#include "Settings.cpp"

#define CHECKING_CURRENT_EN 0
#define MAX_CURRENT 1
#define MAX_CURRENT_TIME 2

int16_t volatile current[2] = {0, 0};
int16_t volatile timerCrash = 0;
int16_t volatile timerCrashCounter = 0;
bool crashedFlag = false;

void initTimerCrash(void)
{
	TCCR2B |= (1 << CS22)|(1 << CS21)|(1 << CS20);
	TIMSK2 |= (1 << TOIE2);
}

int main(void)
{
	_delay_ms(100);
	
	CurrentADC currentADC;
	Uart uart;
	Buttons buttons;
	Settings set;

	currentADC.Init_ADC();
	uart.InitUart(19200);
	uart.getchUartEn();
	buttons.initButtons();
	buttons.initMotor();
	buttons.initTimer0();
	initTimerCrash();
	
	bool buttonState[2] = {false, false};
	int8_t rotate = 0;
	uint8_t motorSettings[3];
	
	for(uint8_t i = 0; i < 3; i++)
	{
		motorSettings[i] = *(set.readFromEepromForAnalysis() + i);
	}
	
	sei();
	
    while(1)
    {
		//Checking currents
		if(crashedFlag == false)
		{
			for(uint8_t i = 0; i < 2; i++)
			{
				current[i] = currentADC.getADC(i);
				
				if(buttonState[i] != buttons.getButtonState(i))
				{
					buttonState[i] = buttons.getButtonState(i);
					switch(buttonState[i])
					{
						case true:
						buttons.disableMotor();
						_delay_ms(100);
						buttons.motorRotate(i);
						_delay_ms(100);
						buttons.enableMotor();
						rotate = i+1;
						break;
						
						case false:
						buttons.disableMotor();
						buttons.motorStop();
						rotate = 0;
						break;
					}
				}
			}
		}
		
		//Checking Uart
		switch(uart.readRxCommand())
		{
			case COM_1:
			_delay_ms(100);
			uart.sendUartEn();
			uart.sendTxBuff(current[0], rotate, 1);
			uart.clearRxBuff();
			uart.getchUartEn();
			break;
			
			case COM_2:
			_delay_ms(100);
			uart.sendUartEn();
			uart.sendTxBuff(current[1], rotate, 2);
			uart.clearRxBuff();
			uart.getchUartEn();
			break;
			
			case COM_Q:
			_delay_ms(100);
			uart.sendUartEn();
			uart.sendTxBuff("Arduino is found");
			uart.clearRxBuff();
			uart.getchUartEn();
			break;
			
			case COM_SW:
			_delay_ms(100);
			set.writeToEeprom(uart.getSettings());
			
			for(uint8_t i = 0; i < 3; i++)
			{
				motorSettings[i] = *(set.readFromEepromForAnalysis() + i);
			}
			uart.sendUartEn();
			uart.sendTxBuff("Ok_S");
			uart.clearRxBuff();
			uart.getchUartEn();
			break;
			
			case COM_SR:
			_delay_ms(100);
			uart.sendUartEn();
			uart.sendTxBuff(set.readFromEepromForSend());
			uart.clearRxBuff();
			uart.getchUartEn();
			break;
		}
		
		//Crashing of motors
		//if(motorSettings[CHECKING_CURRENT_EN] == 0x31)
		//{
			if((current[0] > 400) || (current[1] > 400))
			{
				timerCrashCounter = 1;
				if(timerCrash > 8)
				{
					buttons.disableMotor();
					buttons.motorStop();
					_delay_ms(100);
					timerCrashCounter = 0;
					timerCrash = 0;
					crashedFlag = true;
					current[0] = 0;
					current[1] = 0;
					rotate = 0;
				}
			}
			else
			{
				timerCrashCounter = 0;
				timerCrash = 0;
			}
		//}
    }
}

ISR(TIMER2_OVF_vect)
{
	timerCrash += timerCrashCounter;
}

ISR(ADC_vect, ISR_BLOCK)
{
	CurrentADC::ADC_INTERRUPT();
}

ISR(USART_RX_vect, ISR_BLOCK)
{
	Uart::readByte();
}

ISR(TIMER0_OVF_vect, ISR_NOBLOCK)
{
	Buttons::checkButtonsState();
}