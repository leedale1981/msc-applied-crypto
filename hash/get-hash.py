import sys
import passlib.hash


def main(argv):
    value = argv[0]
    hashType = argv[1]
    salt = "somesalt"

    if len(argv) > 2:
        salt = argv[2]

    if hashType == "LM":
        print("LM Hash: " + passlib.hash.lmhash.hash(value))

    if hashType == "NT":
        print("NT Hash: " + passlib.hash.nthash.hash(value))

    if hashType == "APR1":
        print("APR1 Hash: " + passlib.hash.apr_md5_crypt.hash(value, salt=salt))

    if hashType == "SHA1":
        print("SHA1 Hash: " + passlib.hash.sha1_crypt.hash(value, salt=salt))

    if hashType == "SHA256":
        print("SHA256 Hash: " + passlib.hash.sha256_crypt.hash(value, salt=salt))

    if hashType == "SHA512":
        print("SHA512 Hash: " + passlib.hash.sha512_crypt.hash(value, salt=salt))

    if hashType == "PBKDF2":
        print("PBKDF2 SHA512 Hash: " +
              passlib.hash.pbkdf2_sha512.hash(value, salt=salt.encode()))


main(sys.argv[1:])
