pub enum TestEnum {
    None,
    First,
    Second,
    Third,
}

pub fn test_enum_to_string(value: TestEnum) -> String {
    match value {
        TestEnum::None => String::from("None"),
        TestEnum::First => String::from("First"),
        TestEnum::Second => String::from("Second"),
        TestEnum::Third => String::from("Third"),
        _ => String::from("Unknown"),
    }
}

pub fn add(x: usize, y: usize) -> usize {
    x + y
}