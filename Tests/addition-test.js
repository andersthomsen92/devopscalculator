import { Selector } from 'testcafe';

fixture `Calculator Test`
    .page `http://79.76.54.224/`; 

test('Simple Calculator Add Operation', async t => {
    
    // Select the calculator type and operation
    const calculatorTypeSelect = Selector('#calculatorType');
    const operationSelect = Selector('#operation');
    const numberAInput = Selector('#numberA');
    const numberBInput = Selector('#numberB');
    const calculateButton = Selector('#calculateButton');
    const resultDisplay = Selector('#resultDisplay');

    // Select "Simple Calculator" and "Addition" operation
    await t
        .click(calculatorTypeSelect)
        .click(calculatorTypeSelect.child('option').withText('Simple Calculator'))
        .click(operationSelect)
        .click(operationSelect.child('option').withText('Addition (+)'))
        // Enter numbers 1 and 1
        .typeText(numberAInput, '1')
        .typeText(numberBInput, '1')
        // Click the calculate button
        .click(calculateButton)
        // Assert that the result is 2
        .expect(resultDisplay.innerText).contains('Result: 2');
});
