import { useState, ChangeEvent } from 'react';
import { useFormik } from 'formik'
import * as Yup from 'yup'
import './index.css';

const basicValidationSchema = Yup.object().shape({
    field1: Yup.string().required()
});

const addValidationSchema = Yup.object().shape({
    field2: Yup.string().required()
});

const TestFormik: React.FC = () => {
    const [addField2, setAddField2] = useState(false);
    const [validationSchema, setValidationSchema] = useState(basicValidationSchema);

    const formik = useFormik({
        onSubmit(values, formikHelpers) {
            console.log("%o %o", values, formikHelpers);
        },
        validationSchema: validationSchema,
        initialValues: {
            field1: "",
            field2: ""
        }
    });

    const handleAddField2Change = (e: ChangeEvent<HTMLInputElement>) => {
        setAddField2(e.target.checked);

        if (e.target.checked) {
            setValidationSchema(basicValidationSchema.concat(addValidationSchema));
        } else {
            setValidationSchema(basicValidationSchema);
        }
    };

    const handleSubmit = () => {
        console.log("handleSubmit() %o", formik);
    };

    console.log("values=%o errors=%o", formik.values, formik.errors);

    return (
        <div>
            <h1>Test Formik</h1>
            <hr/>
            <label htmlFor="addField2">Add Field #2</label>
            <input
                id="addField2"
                name="addField2"
                type="checkbox"
                onChange={handleAddField2Change}
            />
            <br/>
            <div>
            <label htmlFor="field1">Field #1</label>
            <input
                id="field1"
                name="field1"
                type="text"
                onChange={formik.handleChange}
                value={formik.values.field1}
                placeholder="Enter Field #1"
                onBlur={formik.handleBlur}
                className={formik.errors.field1 && formik.touched.field1 ? "input-error" : ""}
            />
            {formik.errors.field1 && formik.touched.field1 && <p className="error">{formik.errors.field1}</p>}
            </div>
            <div hidden={!addField2}>
            <label htmlFor="field1">Field #2</label>
            <input
                id="field2"
                name="field2"
                type="text"
                onChange={formik.handleChange}
                value={formik.values.field2}
                placeholder="Enter Field #2"
                onBlur={formik.handleBlur}
                className={formik.errors.field2 && formik.touched.field2 ? "input-error" : ""}
            />
            {formik.errors.field2 && formik.touched.field2 && <p className="error">{formik.errors.field2}</p>}
            </div>
            <hr/>
            {formik.isValid && formik.touched && (
                <input
                    type="button"
                    value="Submit"
                    onClick={handleSubmit}
                />
            )}
        </div>
    );
}

export default TestFormik;