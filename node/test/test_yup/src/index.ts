import * as Yup from "yup";

const testSchema = Yup.object({
  pStringRequired: Yup.string().required("pStringRequired"),
  pString: Yup.string().optional(),
});

type TestType = Yup.InferType<typeof testSchema>;

async function main() {
  try {
    const o = await testSchema.validate({});
  } catch (error) {
    console.log(error);
  }

  try {
    const parsedO = testSchema.cast({});
  } catch (error) {
    console.log(error);
  }
}

main().catch((error) => {
  console.log(error);
});
