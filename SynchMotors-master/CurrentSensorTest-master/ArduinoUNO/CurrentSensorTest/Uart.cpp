#include "Uart.h"
#include <avr/io.h>

volatile char Uart::rxBuff[RX_BUFF_LENGTH];
volatile uint8_t Uart::counterRxBuff = 0;
volatile char Uart::currentByte = 0;

void Uart::InitUart(uint16_t speed)
{
	// setting the baud rate
	UBRR0 = F_CPU/16/speed-1;
	// enabling TX & RX
	UCSR0A = (1 << UDRE0);
	UCSR0C =  (1 << UCSZ01)|(1 << UCSZ00); //Set frame: 8data, 1 stop
}

void Uart::sendUartEn(void)
{
	UCSR0B = (1 << TXEN0);
}


void Uart::getchUartEn(void)
{
	UCSR0B = (1 << RXCIE0)|(1 << RXEN0);
}


void Uart::readByte(void)
{
	currentByte = UDR0; //Считывание Uart
	
	//Признак начала посылки
	if(currentByte == '<')
	{
		counterRxBuff = 0;
		for(uint8_t i = 1; i < RX_BUFF_LENGTH; i++)
		{
			rxBuff[i] = 0;
		}
	}
	
	//Заполнение буфера
	if(counterRxBuff < RX_BUFF_LENGTH)
	{
		rxBuff[counterRxBuff] = currentByte;
		counterRxBuff++;
	}
	
	//Очистка буфера при переполнении
	else
	{
		for(uint8_t i = 0; i < RX_BUFF_LENGTH; i++)
		{
			rxBuff[i] = 0;
		}
		counterRxBuff = 0;
	}
}

uint8_t Uart::readRxCommand(void)
{			
	for(uint8_t i = 0; i < RX_BUFF_LENGTH; i++)
	{
		if((rxBuff[i] == '<') && (rxBuff[i+2] == '>'))
		{
			switch(rxBuff[i+1])
			{
				case '1':
				uartCommand = COM_1;
				break;
				
				case '2':
				uartCommand = COM_2;
				break;
				
				case 'Q':
				uartCommand = COM_Q;
				break;
				
				case 'S':
				uartCommand = COM_SR;
				break;
			}
		}
		
		else if((rxBuff[i] == '<') && (rxBuff[i+9] == '>'))
		{
			if((rxBuff[i+1] == 'P') && (rxBuff[i+8] == 'p'))
			{
				settings[0] = rxBuff[2] << 8 | rxBuff[3];
				settings[1] = rxBuff[4] << 8 | rxBuff[5];
				settings[2] = rxBuff[6] << 8 | rxBuff[7];
			}
			uartCommand = COM_SW;
		}
		
	}
	return uartCommand;	
}

void Uart::sendTxBuff(char *txBuff)
{
	for(uint8_t i = 0; txBuff[i] != '\0'; i++)
	{
		while(!(UCSR0A & (1<<UDRE0)));
		UDR0 = txBuff[i];
	}
}

void Uart::sendTxBuff(int16_t currentData, int8_t rotate, uint8_t group)
{
	switch(group)
	{
		case 1:
		data[0] = '<'; data[1] = '1'; data[2] = (currentData >> 8); data[3] = currentData; data[4] = rotate; data[5] = '>';
		break;
		
		case 2:
		data[0] = '<'; data[1] = '2'; data[2] = (currentData >> 8); data[3] = currentData; data[4] = rotate; data[5] = '>';
		break;
	}

	for(uint8_t i = 0; i < 6; i++)
	{
		while(!(UCSR0A & (1<<UDRE0)));
		UDR0 = data[i];
	}
}

void Uart::clearRxBuff(void)
{
	for(uint8_t i = 0; i < RX_BUFF_LENGTH; i++)
	{
		rxBuff[i] = 0;
	}
	uartCommand = COM_NO;
}

uint16_t* Uart::getSettings(void)
{
	return settings;
}
