import { useState, ChangeEvent } from "react";
import "./index.css";

export interface CardData {
  cardNumber?: string;
  expiration?: string;
  expirationMonth?: string;
  expirationYear?: string;
  cardHolder?: string;
  cardHolderFirstMiddleName?: string;
  cardHolderLastName?: string;
}

export type CardNumberInputProps = {
  numberLength?: number | number[];
  onChange?: (cardData?: CardData) => void;
};

const isDigit = (str: string) => !/\D/.test(str);

const reCardTrack1 = /%b(\d+?)\^(.+?)\/(.+?)\^(\d{2})(\d{2})(?=\d)/i;

const parseCard = (value?: string) => {
  if (!value) {
    return undefined;
  }

  const matches = value!.match(reCardTrack1);
  if (!Array.isArray(matches)) {
    return undefined;
  }

  let [
    ,
    cardNumber = undefined,
    lastName = undefined,
    firstMiddleName = undefined,
    expirationYear = undefined,
    expirationMonth = undefined,
  ] = matches;

  return {
    cardNumber,
    lastName,
    firstMiddleName,
    expirationMonth,
    expirationYear,
  };
};

const isCardNumber = (value?: string, cardNumberLength?: number | number[]) => {
  if (!value || !cardNumberLength) {
    return false;
  }

  const cardNumberLengths = Array.isArray(cardNumberLength)
    ? cardNumberLength
    : [cardNumberLength];

  let isMatch = false;

  for (let i = 0, l = cardNumberLengths.length; i < l; ++i) {
    const cardNumberLength = cardNumberLengths[i];
    const reCardNumber = new RegExp(`\\d{${cardNumberLength}}`);

    if (reCardNumber.test(value)) {
      isMatch = true;
      break;
    }
  }

  return isMatch;
};

const isDatePart = (value?: string, testFn?: Function) => {
  if (!value || !isDigit(value)) {
    return false;
  }
  const _part = parseInt(value, 10);

  return testFn?.(_part);
};

const isMonth = (value?: string) =>
  isDatePart(
    value,
    (_month: number) => !isNaN(_month) && _month > 0 && _month < 13
  );

const isYear = (value?: string) =>
  isDatePart(value, (_year: number) => !isNaN(_year) && _year > 0);

const toCardData = (
  cardNumber?: string,
  expirationMonth?: string,
  expirationYear?: string,
  firstMiddleName?: string,
  lastName?: string
) => ({
  cardNumber: cardNumber,
  ...(isYear(expirationYear) &&
    isMonth(expirationMonth) && {
      expiration: `${expirationYear}${expirationMonth}`,
    }),
  ...(isMonth(expirationMonth) && {
    expirationMonth: expirationMonth,
  }),
  ...(isYear(expirationYear) && {
    expirationYear: expirationYear,
  }),
  ...(!!firstMiddleName &&
    !!lastName && {
      cardHolder: `${firstMiddleName.trim()} ${lastName.trim()}`,
    }),
  ...(!!firstMiddleName && {
    cardHolderFirstMiddleName: firstMiddleName.trim(),
  }),
  ...(!!lastName && { cardHolderLastName: lastName.trim() }),
});

const CardNumberInput: React.FC<CardNumberInputProps> = ({
  numberLength = undefined,
  onChange = undefined,
}) => {
  console.log("CardNumberInput() started");

  const [value, setValue] = useState<string | undefined>("");

  const handleInputChange = (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const value = e.target.value;

    setValue((prev) => {
      console.log(
        "CardNumberInput handleInputChange setValue(%o => %o)",
        prev,
        value
      );
      return value;
    });

    const card = parseCard(value);
    if (card) {
      if (isCardNumber(card.cardNumber, numberLength)) {
        setValue((prev) => {
          console.log(
            "CardNumberInput handleInputChange setValue(%o => %o)",
            prev,
            card.cardNumber
          );
          return card.cardNumber;
        });

        onChange?.(
          toCardData(
            card.cardNumber,
            card.expirationMonth,
            card.expirationYear,
            card.firstMiddleName,
            card.lastName
          )
        );
      }
    } else if (isCardNumber(value, numberLength)) {
      onChange?.(toCardData(value));
    }
  };

  return <input type="text" value={value} onChange={handleInputChange} />;
};

export default CardNumberInput;
