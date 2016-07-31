Add reference to following dll:

iKoot.dll - encryption/decryption
	def: string iKoot.KootRoop.Encrypt(string something_to_encrypt)
	usage: strKey = iKoot.KootRoop.Encrypt(something_to_encrypt);
	similar for Decrypt

iSuraksha.dll - get hash from mac/cpu/bios to be used as system key
	def: string iSuraksha.FingerPrint.GetMacHash()
	usage: macHash = iSuraksha.FingerPrint.GetMacHash()


iKey.dll should be in root directory of program executable,
which contains serial number with following declaration:
	public class iKey {public static string key="abcdefg";

