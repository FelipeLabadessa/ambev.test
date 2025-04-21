




-- Insert 3 Users
INSERT INTO "Users" ("Id", "Username", "Password", "Email", "Phone", "Status", "Role", "CreatedAt", "UpdatedAt") VALUES 
('28c3607a-f5d0-45c2-9665-4d6d90535d41', 'admin', '$2a$11$IWv6TqADTbHpEBJ0O5DiLOeCQl8nVdbljmfCVjZttzseHFO4LPpUe', 'admin@ambev.com', '123-456-7890', 'Active', 'Admin', '2024-12-09 01:25:11', NULL),
('42019ee9-0eb0-4de6-930c-5221609008eb', 'customer', '$2a$11$IWv6TqADTbHpEBJ0O5DiLOeCQl8nVdbljmfCVjZttzseHFO4LPpUe', 'seller1@ambev.com', '123-456-7890', 'Active', 'Costumer', '2024-12-09 01:25:11', NULL),
('56b5f658-f746-487a-82f7-6dfaa5cf7f5f', 'manager', '$2a$11$IWv6TqADTbHpEBJ0O5DiLOeCQl8nVdbljmfCVjZttzseHFO4LPpUe', 'seller2@ambev.com', '123-456-7890', 'Active', 'Manager', '2024-12-09 01:25:11', NULL);

-- Insert 10 Customers
INSERT INTO "Customers" ("Id", "Name", "CreatedAt", "UpdatedAt") VALUES 
('deeef68d-b504-4da4-9230-4c09322f7717', 'Customer 1', '2024-12-09 01:25:11', NULL),
('582e461a-b1dd-4678-90b2-49314bd4cc38', 'Customer 2', '2024-12-09 01:25:11', NULL),
('e7ed3de1-2761-4883-9e89-87b9a6d68bfe', 'Customer 3', '2024-12-09 01:25:11', NULL),
('ad7952ad-0455-4baa-a032-684482fad6d3', 'Customer 4', '2024-12-09 01:25:11', NULL),
('bac9e5c0-20b1-4dc0-ab49-fbfb0727eec7', 'Customer 5', '2024-12-09 01:25:11', NULL),
('33f07d79-9d2f-4e81-a8fa-fac82dfb600f', 'Customer 6', '2024-12-09 01:25:11', NULL),
('ac12f51d-4515-425e-acc5-b649ffdacde7', 'Customer 7', '2024-12-09 01:25:11', NULL),
('d497d2e1-2907-4913-949b-8b464d39daf7', 'Customer 8', '2024-12-09 01:25:11', NULL),
('09ccc8d5-7749-4aec-af56-5bb17370914b', 'Customer 9', '2024-12-09 01:25:11', NULL),
('12905a87-a3d3-4020-8815-d0c79691314b', 'Customer 10', '2024-12-09 01:25:11', NULL);

-- Insert 10 Products
INSERT INTO "Products" ("Id", "Name", "UnitPrice", "CreatedAt", "UpdatedAt") VALUES 
('7c8beda6-8abb-429b-b7a5-a0922878c272', 'Product 1', 58.34, '2024-12-09 01:25:11', NULL),
('7b020e77-2e48-4bb4-99dc-266802ee5b86', 'Product 2', 75.03, '2024-12-09 01:25:11', NULL),
('f880c5a5-6bd6-465d-bf8f-9b5dc050580f', 'Product 3', 89.66, '2024-12-09 01:25:11', NULL),
('818e859b-6a83-443e-b637-0ef4ad68242a', 'Product 4', 73.23, '2024-12-09 01:25:11', NULL),
('0211b0a0-a9ae-43d9-a16e-81de75b40fd0', 'Product 5', 35.19, '2024-12-09 01:25:11', NULL),
('c7e9feaf-39eb-48a4-9628-7fee739c9607', 'Product 6', 34.05, '2024-12-09 01:25:11', NULL),
('cb4e5f17-e3e2-41d2-ae54-963a7ae1b73c', 'Product 7', 92.78, '2024-12-09 01:25:11', NULL),
('6b07b8be-beb2-47c6-b592-714a0f00adf6', 'Product 8', 73.01, '2024-12-09 01:25:11', NULL),
('907de94e-fdaf-488a-83e2-4c5479b2172d', 'Product 9', 28.67, '2024-12-09 01:25:11', NULL),
('f31fe4ee-e9de-4ab6-bee6-ae5ed519b5e9', 'Product 10', 2.38, '2024-12-09 01:25:11', NULL);

-- Insert 10 Sales
INSERT INTO "Sales" ("Id", "SaleNumber", "Date", "CustomerID", "TotalAmount", "BranchId", "Status", "CreatedAt", "UpdatedAt") VALUES 
('9460ab33-1649-4e05-bee6-e197790d6ced', '64226071-ae6a-48be-93db-0e76e572cd35', '2024-12-09 01:25:11', 'deeef68d-b504-4da4-9230-4c09322f7717', 731.36, '22b7155b-3f25-493c-ad1b-8f39ee41c71f', 'Active', '2024-12-09 01:25:11', NULL),
('256a9d5a-f6f1-4d83-9cdd-722be4695197', '08cdd52f-81d4-4ad5-a4bc-707263514cc4', '2024-12-09 01:25:11', '582e461a-b1dd-4678-90b2-49314bd4cc38', 433.10, 'a2541bda-171a-4fb8-aa74-b8e5f5918c50', 'Active', '2024-12-09 01:25:11', NULL),
('573b12ae-d277-40f1-95ef-2e4a2afa6118', '569daea8-319f-440a-b9fa-e6ccd96bc603', '2024-12-09 01:25:11', 'e7ed3de1-2761-4883-9e89-87b9a6d68bfe', 779.37, '71988890-00db-41db-a758-cfb49b936232', 'Active', '2024-12-09 01:25:11', NULL),
('1ed2b4fc-a556-45af-8ca2-f620ee1f15ab', '6f5a6b9e-46e0-45da-817c-390b356c306f', '2024-12-09 01:25:11', 'ad7952ad-0455-4baa-a032-684482fad6d3', 424.72, 'ecaaf4ea-17de-468f-80ca-4e9fd5c6d560', 'Active', '2024-12-09 01:25:11', NULL),
('9832f8eb-e2ca-4aa1-9632-5dede6d59ed1', '08fe32af-07b2-4d68-8ad8-b5b29306b9ed', '2024-12-09 01:25:11', 'bac9e5c0-20b1-4dc0-ab49-fbfb0727eec7', 219.53, '30348e16-cc75-4fd0-80bf-6fe25d06c2ed', 'Active', '2024-12-09 01:25:11', NULL),
('097bc88c-020b-4496-91f3-0d07873f0a2f', 'c3080cb4-b710-479b-b233-3b109ed087c8', '2024-12-09 01:25:11', '33f07d79-9d2f-4e81-a8fa-fac82dfb600f', 846.95, 'b3940e96-6377-40c3-9429-43e3ca291e2a', 'Active', '2024-12-09 01:25:11', NULL),
('c5fca2d4-6525-4992-a93a-f92c4d17afc5', '39be189a-f609-43cb-be7c-c2e6f9724746', '2024-12-09 01:25:11', 'ac12f51d-4515-425e-acc5-b649ffdacde7', 213.12, 'ee6d5cf2-e02d-4a76-8b07-66a65bf7a36e', 'Active', '2024-12-09 01:25:11', NULL),
('b3ce6dfd-70be-4f0f-bcbd-27b26fba1b5a', 'b946fe7c-fe45-431e-9e79-bca4f132e83a', '2024-12-09 01:25:11', 'd497d2e1-2907-4913-949b-8b464d39daf7', 753.53, '0e6f5ff1-6e65-4f2e-a26e-166d56e77a5e', 'Active', '2024-12-09 01:25:11', NULL),
('ddd62f37-5aae-4308-936d-c5d38d95c648', 'fdb5e5aa-bde8-4d70-b5ca-8d54a24e46af', '2024-12-09 01:25:11', '09ccc8d5-7749-4aec-af56-5bb17370914b', 134.11, '99a3ccc1-c4c2-4207-ab21-2192abddc23b', 'Active', '2024-12-09 01:25:11', NULL),
('8a64171f-f64f-4d9a-b25c-2e5035b05c2a', '26310e3f-3bcd-49f4-9f0c-9733ce19d176', '2024-12-09 01:25:11', '12905a87-a3d3-4020-8815-d0c79691314b', 136.40, '59fe4c1d-439f-4a1c-af4c-cecf399a6ec8', 'Active', '2024-12-09 01:25:11', NULL);


-- Insert SaleProducts
INSERT INTO "SaleProducts" ("SaleId", "ProductId", "Quantity", "TotalPrice", "ProductName", "CreatedAt", "UpdatedAt") VALUES
('9460ab33-1649-4e05-bee6-e197790d6ced', '7c8beda6-8abb-429b-b7a5-a0922878c272', 3, 175.02, 'Product 1', '2024-12-09 01:25:11', NULL),
('9460ab33-1649-4e05-bee6-e197790d6ced', '7b020e77-2e48-4bb4-99dc-266802ee5b86', 2, 150.06, 'Product 2', '2024-12-09 01:25:11', NULL),
('256a9d5a-f6f1-4d83-9cdd-722be4695197', 'f880c5a5-6bd6-465d-bf8f-9b5dc050580f', 1, 89.66, 'Product 3', '2024-12-09 01:25:11', NULL),
('256a9d5a-f6f1-4d83-9cdd-722be4695197', '818e859b-6a83-443e-b637-0ef4ad68242a', 4, 292.92, 'Product 4', '2024-12-09 01:25:11', NULL),
('573b12ae-d277-40f1-95ef-2e4a2afa6118', '0211b0a0-a9ae-43d9-a16e-81de75b40fd0', 5, 175.95, 'Product 5', '2024-12-09 01:25:11', NULL),
('573b12ae-d277-40f1-95ef-2e4a2afa6118', 'c7e9feaf-39eb-48a4-9628-7fee739c9607', 7, 238.35, 'Product 6', '2024-12-09 01:25:11', NULL),
('1ed2b4fc-a556-45af-8ca2-f620ee1f15ab', 'cb4e5f17-e3e2-41d2-ae54-963a7ae1b73c', 2, 185.56, 'Product 7', '2024-12-09 01:25:11', NULL),
('1ed2b4fc-a556-45af-8ca2-f620ee1f15ab', '6b07b8be-beb2-47c6-b592-714a0f00adf6', 8, 584.08, 'Product 8', '2024-12-09 01:25:11', NULL),
('9832f8eb-e2ca-4aa1-9632-5dede6d59ed1', '907de94e-fdaf-488a-83e2-4c5479b2172d', 3, 86.01, 'Product 9', '2024-12-09 01:25:11', NULL),
('9832f8eb-e2ca-4aa1-9632-5dede6d59ed1', 'f31fe4ee-e9de-4ab6-bee6-ae5ed519b5e9', 10, 23.80, 'Product 10', '2024-12-09 01:25:11', NULL);

