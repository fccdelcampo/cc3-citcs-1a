# ATM Program
# By: Francis Carlo Del Campo (CITCS-1A)
# CC3 - Object-Oriented Programming

border = "=================================================="

class ATM_User:
    balance = 10000
   
    def __init__(self, name, password, pin):
        self.name = name
        self.password = password
        self.pin = pin
       
    def deposit(self, amount):
        self.balance += int(amount)
        return self.balance
   
    def withdraw(self, amount):
        if self.balance > amount:
            self.balance -= amount
            return self.balance
        else:
            return None
       
    def checkBalance(self):
        return self.balance

    def verifyUserLogIn(self, name, password):
        if self.name == name and self.password == password:
            return True
        else:
            return False
        
    def verifyPIN(self, pin):
        if self.pin == pin:
            return True
        else:
            return False
       
def main():
   
    print(border)
    print("AUTOMATED TELLER MACHINE")
    print(border)
    print("To use this ATM, create an account first.")
   
    # Create account
    while True:
        name = input("Input your desired username -> ")
        password = input("Input your desired password -> ")
        try:
            pin = int(input("Input your desired four- or six-digit Personal Identification Number (PIN) -> "))
                
        except:
            print("Your PIN was invalid. Try again.")
            continue
        
        if len(str(pin)) == 4 or len(str(pin)) == 6:
                confirm = input(f"Double-check your credentials. \n     Username: {name} \n     Password: {password} \n     PIN: {pin} \n     Do you want to proceed? Y/N -> ")
                if confirm.lower() == 'y':
                    account = ATM_User(name, password, pin)
                    break
                else:
                    print("Try again. If you want to exit, press Ctrl + C.")
        else:
            print("Your PIN was not of the required length of 4 or 6 digits. Try again.")
       
    while True:

        print(border)
        print("You need to log in.")
        name = input("Username -> ")
        password = input("Password -> ")

        if account.verifyUserLogIn(name, password) is True:
            while True:
                print(border)    
                transaction = input("Which transaction do you want? \n    1: Deposit \n    2: Withdraw \n    3: Check Balance \n    4: Exit ATM \n-> ")
                if transaction == '1':
                    print(f"Here's your current balance: {account.checkBalance()}")
                    try:
                        depositAmount = int(input("NOTE: Centavos cannot be deposited. Only type in whole numbers and exclude non-numerical symbols.\nHow much would you want to deposit? Centavos cannot be deposited -> "))
                    except:
                        print("You entered an invalid amount. Try again.")
                        continue
                        
                    confirm = input("Do you want to proceed? Y/N -> ")
                    if confirm.lower() == 'y':
                        print(f"Amount deposited: {depositAmount}")
                        print(f"Current balance: {account.deposit(depositAmount)}")
                        print(border)
                    else:
                        print("Deposit failed.")
                        print(border)
                elif transaction == '2':
                    try:
                        pin = int(input("Enter your Personal Identification Number (PIN) to withdraw -> "))
                    except: 
                        print("Your PIN was invalid. Try again.")
                        continue
                    if account.verifyPIN(pin):
                        try: 
                            withdrawAmount = int(input("NOTE: Centavos cannot be withdrawn. Only type in whole numbers and exclude non-numerical symbols.\nHow much would you want to withdraw? -> "))
                        except:
                            print("You entered an invalid amount. Try again.")
                            continue
                        
                        confirm = input("Do you want to proceed? Y/N -> ")
                        if confirm.lower() == 'y':
                            print(f"Amount to withdraw: {withdrawAmount}")
                            withdrawal = account.withdraw(withdrawAmount)
                            if withdrawal != None:
                                print(f"Current balance: {withdrawal}")
                                print(border)
                            else:
                                print("Withdrawal failed. Current balance is less than withdrawal amount.")
                                print(border)
                        else:
                            print("Deposit failed.")
                    else:
                        print("You entered the wrong PIN. Try again.")
                elif transaction == '3':
                    print(f"Current balance: {account.checkBalance()}")
                    print(border)
                elif transaction == '4':
                    print("You exited from the ATM.")
                    print(border)
                    return
                else:
                    print("Transaction does not exist. Only type in 1, 2, 3, or 4.")
        else:
            print("Wrong username or password. Please log in again. If you want to exit, press Ctrl + C.")
   
if __name__ == "__main__":
    main()
