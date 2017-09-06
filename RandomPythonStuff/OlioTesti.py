
def summaa(numbers):
    if(  len(numbers)==0):
        return 0
    if(len(numbers)==1):
        return numbers[0]

    return     numbers[0] + numbers[1:len(numbers)]


def LaskeKeskiarvo(numbers):
    summaa(numbers)/len(numbers)

class Lukujoukko(object):
    numbers = [0]

    def __init__(self,numbers):
        self.numbers = numbers

    def add(self,amount):
        global numbers
        self.numbers = numbers.append(amount)

    @classmethod
    def keskiarvo(self):
        return LaskeKeskiarvo(self.numbers)

    @classmethod
    def mediaani(self):
        self.numbers.sort()
        luvut = self.numbers
        if(len(luvut)%2!=0):
            i = len(luvut) // 2 + 1
            return float(luvut[i])

        return sum(luvut[len(luvut)//2],numbers(len(luvut)//2+1)/2.0)

def main():
    lukujoukko=Lukujoukko([1,2,2,3,1])
    print("Vastukset: " + lukujoukko.keskiarvo() + " " + lukujoukko.mediaani())





