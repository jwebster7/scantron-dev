# scantron-dev
This is a project for rewriting the Kansas State University Help Desk scantron program to be more legible and user-friendly.

The TS-SCAN folder contains all of the files from the original program written in 1987. Retrieved from Niel Erdwien.

//////////////////////////////////////////////
// Port Communications – Controlled Protocol//
//////////////////////////////////////////////
This should be used on the Host Port Communications Configuration Sheet

• End of Record – signifies an end of record
	o Hex = 24
	o ASCII = ‘$’
• Compress – signifies compression 
	o Example: (#0F) where ‘#’ is compression, ‘0’ is the number of char compressed, and ‘F’ is the char which was compressed
	o Hex = 23
	o ASCII = ‘#’
• Initiate – readies the scantron machine for running sheets 
	o Hex = 40
	o ASCII = ‘@’
• Positive – record received correctly
	o Hex = 2B
	o ASCII = ‘+’
• Negative – record received incorrectly
	o Hex = 2D
	o ASCII = ‘-‘
• Start – raises the hopper
	o Hex = 5B
	o ASCII = ‘[’
• Stop – lowers the hopper
	o Hex = 5D
	o ASCII = ‘]’
• Release
	o Hex = 25
	o ASCII = ‘%’
• Status
	o Hex = 73
	o ASCII = ‘s’
• Mandatory Grids
	o Stop Bits = 1
	o Parity = NONE
	o Baud Rate = 9600
	o Character Bit Length = 8
	o Check Sum = 3
//////////////////////////////////////////////
// Port Communications - CP END             //
//////////////////////////////////////////////
