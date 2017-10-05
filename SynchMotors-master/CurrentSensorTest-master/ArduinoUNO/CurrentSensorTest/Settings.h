#ifndef Settings_H
#define Settings_H

class Settings
{
	private:
		/*[0] - current checking enable: 0 off, 1 - on 
		  [1] - current value: 200 - 1500 mA
		  [2] - current time: 100 - 1000 ms*/
		uint16_t motorSettingsForAnalysis[3];
		char motorSettingsForSend[8];
		
	public:
		void writeToEeprom(uint16_t* data);
		uint16_t* readFromEepromForAnalysis(void);
		char* readFromEepromForSend(void);
};

#endif