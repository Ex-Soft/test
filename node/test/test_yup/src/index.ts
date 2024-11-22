// https://www.codedaily.io/tutorials/How-to-Create-an-Optional-Dynamic-Validation-Schema-based-on-a-Value-with-the-Yup-Validation-Library
// https://stackoverflow.com/questions/73391318/yup-validation-with-dynamic-keys-in-an-object

import * as Yup from "yup";

const testSchema = Yup.object({
  pStringRequired: Yup.string().required("pStringRequired"),
  pString: Yup.string().optional(),
});

type TestType = Yup.InferType<typeof testSchema>;

const optionalRequiredSchema1 = Yup.object().shape({
  optionalObject: Yup.lazy((value) => {
    if (value !== undefined) {
      return Yup.object().shape({
        pStringRequired: Yup.string().required("pStringRequired"),
        pString: Yup.string().optional(),
      });
    }

    return Yup.mixed().notRequired();
  }),
});

const optionalRequiredSchema2 = Yup.object().shape({
  foo: Yup.object({
    entries: Yup.lazy((value) => {
      if (value !== undefined) {
        const validationObject = {
          pStringRequired: Yup.string().required("pStringRequired"),
        };

        const newEntries = Object.keys(value).reduce(
          (acc, val) => ({
            ...acc,
            [val]: Yup.object(validationObject),
          }),
          {}
        );

        return Yup.object().shape(newEntries);
      }

      return Yup.mixed().notRequired();
    }),
  }),
});

try {
  console.log(optionalRequiredSchema1.isValidSync({}));
  console.log(optionalRequiredSchema1.isValidSync({ optionalObject: {} }));

  console.log(optionalRequiredSchema2.isValidSync({}));
  console.log(optionalRequiredSchema2.isValidSync({ foo: {} }));
  console.log(optionalRequiredSchema2.isValidSync({ foo: { entries: {} } }));
  console.log(
    optionalRequiredSchema2.isValidSync({
      foo: { entries: { "2252L": {}, "2252D": {} } },
    })
  );
  console.log(
    optionalRequiredSchema2.isValidSync({
      foo: { entries: { "2252L": { pStringRequired: "pStringRequired" } } },
    })
  );
} catch (error) {
  console.log(error);
}

try {
  const o = testSchema.validateSync({});
} catch (error) {
  console.log(error);
}

try {
  const parsedO: TestType = testSchema.cast({});
} catch (error) {
  console.log(error);
}
