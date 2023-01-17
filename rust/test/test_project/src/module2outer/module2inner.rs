pub enum TestEnumInner {
    None,
    First,
    Second,
    Third,
}

pub fn test_enum_inner_to_string(value: TestEnumInner) -> String {
    match value {
        TestEnumInner::None => String::from("None"),
        TestEnumInner::First => String::from("First"),
        TestEnumInner::Second => String::from("Second"),
        TestEnumInner::Third => String::from("Third"),
        _ => String::from("Unknown"),
    }
}

pub fn add(x: usize, y: usize) -> usize {
    x + y
}