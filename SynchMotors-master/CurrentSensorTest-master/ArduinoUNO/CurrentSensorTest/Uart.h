#ifndef Uart_H
#define Uart_H

#define RX_BUFF_LENGTH 20

#define COM_NO 0
#define COM_1 1
#define COM_2 2
#define COM_3 3
#define COM_4 4
#define COM_Q 5
#define COM_SW 6
#define COM_SR 7

class Uart
{
	private:
		static volatile char rxBuff[RX_BUFF_LENGTH];
		static volatile uint8_t counterRxBuff;
		static volatile char currentByte;
		uint8_t volatile uartCommand;
		char volatile data[6];
		uint16_t settings[3];
	
	public:
		void InitUart(uint16_t speed);
		void sendUartEn(void);
		void getchUartEn(void);
		static void readByte(void);
		uint8_t readRxCommand(void);
		void sendTxBuff(char *txBuff);
		void sendTxBuff(int16_t currentData, int8_t rotate, uint8_t group);
		void clearRxBuff(void);
		uint16_t* getSettings(void);
};

#endif