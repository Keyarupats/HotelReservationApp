IF NOT EXISTS (SELECT 1 FROM tblMenuItems)
BEGIN
    INSERT INTO tblMenuItems (ItemName, Category, UnitPrice, IsAvailable) VALUES
    ('Breakfast Set', 'Food', 250.00, 1),
    ('Chicken Meal', 'Food', 280.00, 1),
    ('Burger & Fries', 'Food', 220.00, 1),
    ('Pancit Canton', 'Food', 180.00, 1),
    ('Coffee', 'Beverage', 70.00, 1),
    ('Soft Drink', 'Beverage', 60.00, 1),
    ('Bottled Water', 'Beverage', 40.00, 1),
    ('Extra Pillow & Towel Set', 'Service', 150.00, 1);
END
GO