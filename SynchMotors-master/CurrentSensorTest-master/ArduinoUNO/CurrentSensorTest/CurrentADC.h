#ifndef CurrentADC_H
#define CurrentADC_H

class CurrentADC
{
	private:
		volatile static int16_t count_ADCL;
		volatile static int16_t count_ADCH;
		volatile static int16_t buffer_ADC1[100];
		volatile static int16_t buffer_ADC2[100];
		volatile static int16_t counter_ADC1;
		volatile static int16_t counter_ADC2;
		volatile static int32_t summa;
		volatile static int16_t data_ADC1;
		volatile static int16_t data_ADC2;
		volatile static int16_t current_ADC;
	
	public:
		void Init_ADC(void);
		void deInit_ADC(void);
		static void ADC_INTERRUPT(void);
		int16_t getADC(uint8_t group);
};

#endif