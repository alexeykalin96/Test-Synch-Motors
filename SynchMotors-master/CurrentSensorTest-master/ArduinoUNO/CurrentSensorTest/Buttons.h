#ifndef Buttons_H
#define Buttons_H

#define BUTTONS_PORT PORTD
#define BUTTONS_DDR DDRD
#define BUTTONS_PIN PIND
#define BUTTON_ONE 6
#define BUTTON_TWO 7

#define MOTOR_DDR DDRB
#define MOTOR_PORT PORTB
#define RIGHT_OUT_1_1 5
#define LEFT_OUT_1_2 4
#define EN_OUT_1 3
#define RIGHT_OUT_2_1 0
#define LEFT_OUT_2_2 1
#define EN_OUT_2 2

class Buttons
{
	private:
		static uint8_t timerOne;
		static uint8_t timerTwo;
		static bool buttonState[2];
		static bool was;
	
	public:
		void initButtons(void);
		void initMotor(void);
		void initTimer0(void);
		static void checkButtonsState(void);
		bool getButtonState(uint8_t number);
		void motorRotate(uint8_t direction);
		void motorStop(void);
		void enableMotor(void);
		void disableMotor(void);
};

#endif