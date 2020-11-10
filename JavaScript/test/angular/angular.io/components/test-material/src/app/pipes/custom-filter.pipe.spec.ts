import { CustomFilterPipe } from './custom-filter.pipe';

describe('CustomFilterPipe', () => {
  it('create an instance', () => {
    const pipe = new CustomFilterPipe();
    expect(pipe).toBeTruthy();
  });

  it('Ok', () => {
    // Arrange
    const pipe = new CustomFilterPipe();
    const items = [
      { id: 1, title: '1st' },
      { id: 2, title: '2nd' },
      { id: 3, title: '3rd' },
    ];
    const filter = (item) => item.id % 2 === 1;

    // Act
    const result = pipe.transform(items, filter);

    // Assert
    expect(result.length).toEqual(2);
    expect(result[0].id).toEqual(1);
    expect(result[1].id).toEqual(3);
  });
});
