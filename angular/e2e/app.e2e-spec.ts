import { VerticalTemplatePage } from './app.po';

describe('Vertical App', function() {
  let page: VerticalTemplatePage;

  beforeEach(() => {
    page = new VerticalTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
