import { TodoDtoToViewPipe } from './todo-dto-to-view.pipe';

describe('TodoDtoToViewPipe', () => {
  it('create an instance', () => {
    const pipe = new TodoDtoToViewPipe();
    expect(pipe).toBeTruthy();
  });
});
